using Microsoft.AspNetCore.Mvc;
using ServicoItem.Models;
using ServicoItem.Services;

namespace ServicoItem.Controllers
{
    #region DTO
    public class InserirItemDTO
    {
        public string CodItem { get; set; }
        public string NomeItem { get; set; }
        public string DescricaoItem { get; set; }
        public decimal PrecoItem { get; set; }
    }
    #endregion

    [Controller]
    [Route("api/[Controller]")]
    public class ItemControlador:ControllerBase
    {
        public ItemService _itemService {  get; set; }
        public ItemControlador() 
        {
            _itemService = new ItemService();
        }

        [HttpPost]
        public IActionResult Inserir([FromBody]InserirItemDTO inserirItemDTO)
        {
            try
            {
                var item = new Item()
                {
                    CodItem = inserirItemDTO.CodItem,
                    NomeItem = inserirItemDTO.NomeItem,
                    DescricaoItem = inserirItemDTO.DescricaoItem,
                    PrecoItem = inserirItemDTO.PrecoItem
                };
                _itemService.InserirItem(item);

                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult BuscarPorId([FromRoute]int id) {
            try
            {
                var item = _itemService.FindById(id);
                if (item == null) { 
                    return NotFound(new { Message = $"Item com ID {id} não encontrado." });
                }
                return Ok(item);
            }
            catch (Exception e) {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }

        [HttpGet]
        public IActionResult BuscarTodos() {
            try
            {
                var item = _itemService.FindAll();

                if (item == null)
                {
                    return NotFound(new { Message = $"Nehum Item cadastrado ainda" });
                }

                return Ok(item);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeletarPorId([FromRoute] int id)
        {
            try
            {
                var check = _itemService.DeleteById(id);
                if (check == false)
                {
                    return NotFound(new { Message = $"Houve problema ao deletar o item" });
                }

                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
