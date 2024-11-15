using ServicoItem.Models;
using ServicoItem.Repositorio.Infra;

namespace ServicoItem.Repositorio
{
    public class ItemRepository
    {
        
        public DataContext _dataContext {  get; set; }
        public ItemRepository() { 
            _dataContext = GeradorDeServicos.CarregarContexto();
        }
        public void Inserir(Item item) { 
            _dataContext.Add(item);
            _dataContext.SaveChanges();
        }

        public Item FindById(int id) {
            return _dataContext.Find<Item>(id);
        }

        public List<Item> FindAll() { 
            return _dataContext.Set<Item>().ToList();
        }

        public void DeleteById(Item item) { 
             _dataContext.Remove(item);
             _dataContext.SaveChanges();
        }

        public void UpdateById(Item item) { 
            _dataContext.Update(item);
            _dataContext.SaveChanges(); 
        }
    }
}
