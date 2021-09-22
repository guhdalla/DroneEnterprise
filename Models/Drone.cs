using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula02.Web.Models
{
    public class Drone
    {      
        public int Id { get; set; }
        public string Frame { get; set; }
        public int MotorKV { get; set; }

        public int Battery { get; set; }

        [DataType(DataType.Date), Display(Name = "Data de Fabricacao")]
        public DateTime DataFabricacao { get; set; }

        public TipoDrone Tipo { get; set; }

        public bool Ativo { get; set; }

    }

    public enum TipoDrone
    {
        Racer, Freestyle, Cinewhoopy
    }
}
