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

        public bool UpdateById(int id,Item item) {

            var itemDTO = _itemRepository.FindById(id);
            if (itemDTO == null) {
                return false;
            }

            itemDTO.IdItem = id;
            itemDTO.NomeItem = item.NomeItem;
            itemDTO.CodItem = item.CodItem;
            itemDTO.DescricaoItem = item.DescricaoItem;
            itemDTO.PrecoItem = item.PrecoItem;

            _itemRepository.UpdateById(itemDTO);
            return true;
        }
    }
}
