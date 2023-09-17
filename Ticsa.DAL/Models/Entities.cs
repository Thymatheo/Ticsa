using Newtonsoft.Json;

namespace Ticsa.DAL.Models {
    public class Entities<T> : List<T> where T : StdEntity, new() {
        private const string DATA_PATH = "./data";
        private string dataPath = Path.Combine(DATA_PATH, typeof(T).Name + ".json");
        public Entities() {
            FileInfo file = new FileInfo(dataPath);
            if (!file.Exists) file.Create();
            else {
                string fileContent = File.ReadAllText(dataPath);
                if (!string.IsNullOrEmpty(fileContent))
                    AddRange(JsonConvert.DeserializeObject<IEnumerable<T>>(fileContent)!);
            }
        }
        public new T Add(T entity) {
            base.Add(entity);
            SaveChange();
            return entity;
        }
        public T Update(T entity) {
            this[IndexOf(this.First(x => x.Id == entity.Id))] = entity;
            SaveChange();
            return entity;
        }
        public bool Delete(Guid id) {
            try {
                Remove(this.First(x => x.Id == id));
                SaveChange();
                return true;
            }
            catch { return false; }
        }
        public bool DeleteAll(Predicate<T> predicate) {
            try {
                RemoveAll(predicate);
                SaveChange();
                return true;
            }
            catch { return false; }
        }
        public void SaveChange() {
            bool isSucces = false;
            while (!isSucces) {
                try {
                    File.WriteAllText(dataPath, JsonConvert.SerializeObject(this));
                    isSucces = true;
                }
                catch {
                    isSucces = false;
                }
            }
        }
    }
}
