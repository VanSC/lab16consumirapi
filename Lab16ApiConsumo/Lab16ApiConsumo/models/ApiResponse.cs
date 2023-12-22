using System;
using System.Collections.Generic;
using System.Text;

namespace Lab16ApiConsumo.models
{
    public class Pelicula
    {
        public int id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string genre { get; set; }
        public string image { get; set; }
    }
    public class ApiResponse
    {
        public List<Pelicula> results { get; set; }
    }
}
