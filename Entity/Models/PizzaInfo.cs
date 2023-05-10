    using System;
    using System.Collections.Generic;

    namespace Entity.Models;

    public partial class PizzaInfo
    {
        public long Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }
    }
