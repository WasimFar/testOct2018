using System;
namespace test
{
    public class Asset
    {
        private string name;
        private DateTime time;
        private float bid;
        private float ask;

        public string getName(){
            return this.name;
        }

        public void setName(string name){
            this.name = name;
        }

        public DateTime getTime()
        {
            return this.time ;
        }

        public void setTime(DateTime time)
        {
            this.time = time;
        }

        public float getAsk()
        {
            return this.ask;
        }

        public void setAsk(float ask)
        {
           this.ask = ask;
        }

        public float getBid()
        {
            return this.bid;
        }

        public void setBid(float bid)
        {
           this.bid = bid;
        }

    }
}
