using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Ticsa.DAL.Models;

namespace Ticsa.Filters.ViewModels {
    public interface IMemberFilter {
        public bool IsEnable { get; set; }
        public string Name { get; set; }
        public List<string> Opp { get; }
        public string Opperator { get; set; }
        public bool ApplyFilter(object entity);
        public string Value { get; set; }
        public void UdpateFilterValue(bool isEnable, string value);
    }
    public abstract class MemberFilter<U> : IMemberFilter, INotifyPropertyChanged where U : struct {
        public const string EQUAL_FILTER = "Equal";
        public const string NOT_EQUAL_FILTER = "NotEqual";
        public const string CONTAIN_FILTER = "Contain";
        public const string SUP_FILTER = "Sup";
        public const string INF_FILTER = "Inf";
        public static readonly Dictionary<string, Func<Str, Str, bool>> StringOpperator = new() {
            [EQUAL_FILTER] = (v1, v2) => v1 == v2,
            [NOT_EQUAL_FILTER] = (v1, v2) => v1 != v2,
            [CONTAIN_FILTER] = (v1, v2) => v1.Contains(v2)
        };
        public static readonly Dictionary<string, Func<int, int, bool>> IntOpperator = new() {
            [EQUAL_FILTER] = (v1, v2) => v1 == v2,
            [NOT_EQUAL_FILTER] = (v1, v2) => v1 != v2,
            [SUP_FILTER] = (v1, v2) => v1 > v2,
            [INF_FILTER] = (v1, v2) => v1 < v2,
        };
        public static readonly Dictionary<string, Func<DateTime, DateTime, bool>> DateOpperator = new() {
            [EQUAL_FILTER] = (v1, v2) => v1 == v2,
            [NOT_EQUAL_FILTER] = (v1, v2) => v1 != v2,
            [SUP_FILTER] = (v1, v2) => v1 > v2,
            [INF_FILTER] = (v1, v2) => v1 < v2,
        };

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private bool _isEnable;
        public bool IsEnable {
            get => _isEnable;
            set {
                _isEnable = value;
                OnPropertyChanged();
            }
        }
        public string Name { get; set; }
        public Func<object, U> GetEntity { get; set; }
        public Func<string, U> Parse { get; set; }
        private U _value => Parse(Value);
        public string Value {
            get => val!; set {
                val = value;
                OnPropertyChanged();
            }
        }
        private string? val;
        protected Dictionary<string, Func<U, U, bool>>? Opperators { get; set; }
        public List<string> Opp => Opperators!.Keys.ToList();
        public string Opperator { get; set; } = EQUAL_FILTER;
        public MemberFilter(string name, Func<object, U> getEntity, Func<string, U> parse, U defaultValue) {
            Name = name;
            GetEntity = getEntity;
            Parse = parse;
            Value = defaultValue!.ToString()!;
        }
        public bool ApplyFilter(object entity) =>
            Opperators![Opperator](GetEntity(entity), _value);

        public void UdpateFilterValue(bool isEnable, string value) {
            IsEnable = isEnable;
            Value = value;
        }
    }
    public class StringFilter : MemberFilter<Str> {
        public StringFilter(string name, Func<object, string> getEntity) : base(name, (object obj) => new Str(getEntity(obj)), (str) => new Str(str), new("")) {
            Opperators = StringOpperator;
        }
    }
    public class IntFilter : MemberFilter<int> {
        public IntFilter(string name, Func<object, int> getEntity) : base(name, getEntity, (obj) => string.IsNullOrEmpty(obj) ? 0 : int.Parse(obj), 0) {
            Opperators = IntOpperator;
        }
    }
    public class DateFilter : MemberFilter<DateTime> {
        public DateFilter(string name, Func<object, DateTime> getEntity) : base(name, getEntity, (obj) => string.IsNullOrEmpty(obj) ? DateTime.Now : DateTime.Parse(obj), DateTime.Now) {
            Opperators = DateOpperator;
        }
    }
    public struct Str {
        public Str(string value) {
            Value = value;
        }
        public string Value { get; set; }
        public static bool operator ==(Str a, Str b) => a.Value == b.Value;
        public static bool operator !=(Str a, Str b) => a.Value != b.Value;
        public readonly bool Contains(Str val) => Value.Contains(val.Value);
        public override string ToString() => Value.ToString();
        public override bool Equals([NotNullWhen(true)] object? obj) {
            return base.Equals(obj);
        }
        public override int GetHashCode() => Value.GetHashCode();
    }
}
