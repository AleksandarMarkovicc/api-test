using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiTest.Models
{

    public class CommentModel
    {
        [JsonProperty("postId")]
        public int PostId { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
       
        [JsonProperty("email")]
        public string Email { get; set; }
        
        [JsonProperty("body")]
        public string Body { get; set; } 
    }
}
