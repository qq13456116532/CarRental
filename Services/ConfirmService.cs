namespace Services;


public class ModalData
    {
        public bool IsVisible { get; set; }
        public string? Title { get; set; }
        public FormData Form { get; set; } = new FormData();

        public class FormData
        {
            public string? Name { get; set; }
            public string? Mobile { get; set; }
            public string? Desc { get; set; }
            public bool Default { get; set; }
        }
    }

