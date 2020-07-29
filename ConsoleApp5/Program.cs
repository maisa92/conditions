using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            var x  = CheckDiscountsForConstraints(GetObject(), "598178761", 20);
            Console.WriteLine(x);
            Console.ReadKey();
 
        }

        private static bool  CheckDiscountsForConstraints(DiscountObject discountObject, string cardId, decimal price)
        {
            
               return  DateFromDateTo(discountObject)
                                //& RequiresMemberShip(discountObject, cardId)
                                //& DateTimeFromDateTimeTo(discountObject)
                                //& WeekDay(discountObject)
                                //& UserIdConstraint(discountObject, cardId)
                                //& AgeFromAgeTo(discountObject, cardId)
                                //& TriggeringRuleDepend(discountObject, price)
                                ;

           
        }



        private static bool DateFromDateTo(DiscountObject discount)
        {
            long? dateFrom = discount.DiscountConstraints.FirstOrDefault(x => x.ConstraintType == 1)?.DataAsInteger;
            long? dateTo = discount.DiscountConstraints.FirstOrDefault(x => x.ConstraintType == 2)?.DataAsInteger;

            if (dateFrom == null && dateTo == null)
                return true;

            bool conditionFrom;
            bool conditionTo;

            Console.WriteLine(UnixTimeStampToDateTime((long)dateFrom).Date);
            Console.WriteLine(DateTime.Now.GetTbilisiNow().Date);

            if (dateFrom != null)
                conditionFrom = UnixTimeStampToDateTime((long)dateFrom).Date <= DateTime.Now.GetTbilisiNow().Date;
            else
                conditionFrom = true;

            if (dateTo != null)
                conditionTo = UnixTimeStampToDateTime((long)dateTo).Date > DateTime.Now.GetTbilisiNow().Date;
            else
                conditionTo = true;

            return conditionTo == conditionFrom;
        }


        private static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddMilliseconds(unixTimeStamp).GetTbilisiNow().Date;
            return dtDateTime;
        }

        private static DiscountObject GetObject()
        {
            return new DiscountObject()
            {
                Id = new Guid("F1872CC0-8795-45E3-9474-259E5B313A57"),
                Name = "შეუზღუდავი",
                IsMultiple = true,
                TriggeringPrice = null,
                TriggeringRule = 1,
                DiscountConstraints = GetConstraintList(),
                DiscountResult = GetDiscountResult(),
                TriggeringNthCustomerInPOSPopulation = null,
                TriggeringProducts = GetTriggeringProducts()

            };

        }

        private static List<TriggeringProduct> GetTriggeringProducts()
        {
            return new List<TriggeringProduct>()
           {
               new TriggeringProduct(){
                   Id = 3463,
                   Count= 1,
                   DiscountId = new Guid("F1872CC0-8795-45E3-9474-259E5B313A57"),
                   ProductInternalId = "44d52ce4-9e53-11e5-8f47-001f29efb30a"
               }
           };
        }

        private static DiscountResult GetDiscountResult()
        {
            return new DiscountResult()
            {
                Id = 3431,
                DiscountId = new Guid("F1872CC0-8795-45E3-9474-259E5B313A57"),
                DiscountResultType = 1,
                DiscountResultProductList = getDiscountResultProductList()
            };
        }

        private static List<DiscountResultProduct> getDiscountResultProductList()
        {
            return new List<DiscountResultProduct>() {
                new DiscountResultProduct(){
                    Id = 3448,
                    Count = 1,
                    DiscountAmount = null,
                    DiscountPercent = 100,
                    DiscountResultId = 3431,
                    ProductInternalId = "44d52ce4-9e53-11e5-8f47-001f29efb30a"
                }
            };
        }

        private static List<DiscountConstraint> GetConstraintList()
        {
            return new List<DiscountConstraint>() {
                new DiscountConstraint()
                {
                    Id = 10124,
                    DiscountId = new Guid("F1872CC0-8795-45E3-9474-259E5B313A57"),
                    ConstraintType = 1,
                    DataAsDecimal = null,
                    DataAsText = null,
                    DataAsInteger = 1595966400000
                },
                new DiscountConstraint()
                {
                    Id = 10125,
                    DiscountId = new Guid("F1872CC0-8795-45E3-9474-259E5B313A57"),
                    ConstraintType = 4,
                    DataAsDecimal = null,
                    DataAsText = null,
                    DataAsInteger = 2
                },
                 new DiscountConstraint()
                {
                    Id = 10126,
                    DiscountId = new Guid("F1872CC0-8795-45E3-9474-259E5B313A57"),
                    ConstraintType = 7,
                    DataAsDecimal = null,
                    DataAsText = null,
                    DataAsInteger = 1595923206268
                },
                 new DiscountConstraint()
                {
                    Id = 10127,
                    DiscountId = new Guid("F1872CC0-8795-45E3-9474-259E5B313A57"),
                    ConstraintType = 9,
                    DataAsDecimal = null,
                    DataAsText = null,
                    DataAsInteger = 5
                },
                  new DiscountConstraint()
                {
                    Id = 10128,
                    DiscountId = new Guid("F1872CC0-8795-45E3-9474-259E5B313A57"),
                    ConstraintType = 5,
                    DataAsDecimal = null,
                    DataAsText = null,
                    DataAsInteger = 20
                },
            };
        }
    }


    public class DiscountObject
    { 
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public int? TriggeringRule { get; set; }
        public decimal? TriggeringPrice { get; set; }
        public int? TriggeringNthCustomerInPOSPopulation { get; set; }
        public bool IsMultiple { get; set; }
        public List<TriggeringProduct> TriggeringProducts { get; set; }
        public List<DiscountConstraint> DiscountConstraints { get; set; }
        public DiscountResult DiscountResult { get; set; }
    }

    public class TriggeringProduct
    {
        
        public int? Id { get; set; }
        public Guid? DiscountId { get; set; }
        public string ProductInternalId { get; set; }
        public int? Count { get; set; }
    }

    public class DiscountConstraint
    {
        
        public int? Id { get; set; }
        public Guid DiscountId { get; set; }
        public int ConstraintType { get; set; }
        public long? DataAsInteger { get; set; }
        public decimal? DataAsDecimal { get; set; }
        public string DataAsText { get; set; }
    }


    public class DiscountResult
    {
    
        public List<DiscountResultProduct> DiscountResultProductList { get; set; }
        public int? Id { get; set; }
        public Guid? DiscountId { get; set; }
        public int? DiscountResultType { get; set; }
    }

    public class DiscountResultProduct
    { 
        public int? Id { get; set; }
        public int? DiscountResultId { get; set; }
        public string ProductInternalId { get; set; }
        public int Count { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal? DiscountPercent { get; set; }
    }
}
