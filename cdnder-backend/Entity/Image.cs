using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace cdnder_backend.Entity
{
    public class Image
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        [StringLength((128))]
        [JsonPropertyName("filename")]
        public string Filename { get; set; }
        
        [StringLength((5))]
        [JsonPropertyName("filetype")]
        public string Filetype { get; set; }
        
        [JsonPropertyName("size")]
        public long Size { get; set; }
        
        [JsonPropertyName("suffix")]
        public string Suffix { get; set; }
        
        [JsonPropertyName("created")]
        public DateTime Created { get; set; }

        public Image()
        {
            Id = Guid.NewGuid();
        }
    }
}