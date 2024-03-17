using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalIR.BusinessLayer.Abstract;
using SignalIR.DtoLayer.ContactDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService ContactService)
        {
            _contactService = ContactService;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _contactService.TGetListAll();

            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            Contact Contact = new Contact
            {
                Email = createContactDto.Email,
                FooterDescription = createContactDto.FooterDescription,
                Location = createContactDto.Location,
                PhoneNumber = createContactDto.PhoneNumber
            };

            _contactService.TAdd(Contact);

            return Ok("Contact bilgisi eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var values = _contactService.TGetById(id);

            _contactService.TDelete(values);

            return Ok("Contact bilgisi silindi");
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            Contact Contact = new Contact
            {
                ContactID = updateContactDto.ContactID,
                Email = updateContactDto.Email,
                FooterDescription = updateContactDto.FooterDescription,
                Location = updateContactDto.Location,
                PhoneNumber = updateContactDto.PhoneNumber

            };

            _contactService.TUpdate(Contact);

            return Ok("Contact bilgisi güncellendi.");
        }

        [HttpGet("GetContact")]
        public IActionResult GetContact(int id)
        {
            var value = _contactService.TGetById(id);

            return Ok(value);
        }
    }
}
