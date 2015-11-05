using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BankService
{
    
    public class Service1 : IService1
    {
        static List<int> cardList = new List<int>();
        static int cardNoStart = 1000;
        static int cardNoEnd = 10000;

        public int getCard()
        {
            cardNoStart++;
            if (cardNoStart > cardNoEnd)
            {
                Console.WriteLine("Kindly check the available card numbers between range 1000-10000");
                return 0;
            }
            else
            {
                cardList.Add(cardNoStart);
                return cardNoStart;
                
            }
            
        }

        public string validateCard(string encryptedCardNo)
        {
            try
            {
                DecryptionService.ServiceClient client = new DecryptionService.ServiceClient();
                String decryptedcardNo = client.Decrypt(encryptedCardNo);
                int cardNoInt = int.Parse(decryptedcardNo);

                if (cardList.Contains(cardNoInt))
                    return "valid";
                else
                    return "not valid";
            }
            catch (Exception e)
            {
                return "not valid";
            }
        }
    }
}
