using BomNegocio.DAL.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BomNegocio.API.DTOs
{
    public class WisheDTO
    {
        [JsonIgnore()]
        public DateTime CreationDate { get; set; }
        /* 1..N */
        public int ClientId { get; set; }
        public ClientEntity? Client { get; set; }
        public int AnnouncementId { get; set; }
        public AnnouncementEntity? Announcement { get; set; }
    }
}
