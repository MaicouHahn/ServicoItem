using ServicoItem.Models;
using ServicoItem.Repositorio;

namespace ServicoItem.Services
{
    public class ItemService
    {
        
        public ItemRepository _itemRepository { get; set; }
        public ItemService() { 
            _itemRepository = new ItemRepository();
        }

        public void InserirItem(Item item)
        {
            
            _itemRepository.Inserir(item);
        }
        public Item FindById(int id) { 
            return _itemRepository.FindById(id);

        }
        public List<Item> FindAll() { 
            return _itemRepository.FindAll();
        }

        public bool DeleteById(int id) {
            var item = _itemRepository.FindById(id);
            if (item == null) {
                return false;
            }
            _itemRepository.DeleteById(item);
            return true;
        }
    }
}
