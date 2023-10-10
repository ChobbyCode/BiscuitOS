
namespace BiscuitOS.Tasks
{
    public class Invokement
    {
        public object sender { get; set; }
        public System.EventArgs args { get; set; }

        public Invokement(object sender, System.EventArgs args)
        {
            this.sender = sender;
            this.args = args;
        }
    }
}
