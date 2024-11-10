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
    }
}
