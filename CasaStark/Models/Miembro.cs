﻿using Microsoft.AspNetCore.Mvc;

namespace CasaStark.Models
{
    public class Miembro : Controller
    {
       
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Habilidad { get; set; }
            public string Rol { get; set; }
        
    }
}
