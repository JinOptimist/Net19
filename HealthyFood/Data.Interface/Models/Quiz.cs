

namespace Data.Interface.Models
{
    public class Quiz : BaseModel
    {
        public int QuantityСorrect_answer { get; set; }
        public int QuantityOfPlayers { get; set; }
        public int QuantityOfWinner { get; set; } 
    }
}
