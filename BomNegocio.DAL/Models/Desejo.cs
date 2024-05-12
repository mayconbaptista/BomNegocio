﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomNegocio.DAL.Models
{
    public class Desejo
    {
        public int Id { get; set; }
        /* 1..N */
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
        public int AnuncioId { get; set; }
        public Anuncio? Anuncio { get; set; }
    }
}
