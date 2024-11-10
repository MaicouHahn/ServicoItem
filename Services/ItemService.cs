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
    }
}
