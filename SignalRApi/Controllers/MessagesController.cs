using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalIR.BusinessLayer.Abstract;
using SignalIR.DtoLayer.MessageDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public IActionResult MessageList()
        {
            var values = _messageService.TGetListAll();

            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
            Message Message = new Message
            {
                Content = createMessageDto.Content,
                Email = createMessageDto.Email,
                NameSurname = createMessageDto.NameSurname,
                PhoneNumber = createMessageDto.PhoneNumber,
                SendDate = createMessageDto.SendDate,
                Status = false,
                Subject = createMessageDto.Subject
            };

            _messageService.TAdd(Message);

            return Ok("Mesaj bilgisi eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id)
        {
            var values = _messageService.TGetById(id);

            _messageService.TDelete(values);

            return Ok("Message bilgisi silindi");
        }

        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            Message Message = new Message
            {
                MessageID = updateMessageDto.MessageID,
                Content = updateMessageDto.Content,
                Email = updateMessageDto.Email,
                NameSurname = updateMessageDto.NameSurname,
                PhoneNumber = updateMessageDto.PhoneNumber,
                SendDate = updateMessageDto.SendDate,
                Status = updateMessageDto.Status,
                Subject = updateMessageDto.Subject
            };

            _messageService.TUpdate(Message);

            return Ok("Mesaj bilgisi güncellendi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetMessage(int id)
        {
            var value = _messageService.TGetById(id);

            return Ok(value);
        }
    }
}
