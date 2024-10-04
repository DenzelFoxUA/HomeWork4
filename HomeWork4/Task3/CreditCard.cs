using System.Globalization;

namespace HomeWork4
{
    public enum Currency
    {
        UAH = 1,
        USD = 2,
        EUR,
        PLN,
        GBP,
        CZK
    }
    public class ExpiringDate
    {
        private const int MONTHS_IN_A_YEAR = 12;
        private const int STARTING_YEAR_VALUE = 1950;
        private const int MAX_YEAR_VALUE = 2999;

        public int Month { get; init; }
        public int Year { get; init; }

        public ExpiringDate()
        {
            Month = DateTime.Now.Month;
            Year = DateTime.Now.Year;
        }

        private ExpiringDate(int month, int year)
        {
            Month = month;
            Year = year;
        }

        public static ExpiringDate ExpiringDateBuild(int month, int year)
        {
            int _month = DateTime.Now.Month,
                _year = DateTime.Now.Year;

            if (month > 0 && month <= MONTHS_IN_A_YEAR)
            {
                _month = month;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Month value is not valid");
            }

            if (year > STARTING_YEAR_VALUE && year <= MAX_YEAR_VALUE)
            {
                _year = year;
            }
            else
            {
                throw new ArgumentOutOfRangeException($"Year value is not valid. " +
                    $"It must be greater than {STARTING_YEAR_VALUE}");
            }

            return new ExpiringDate(_month, _year);
        }

        public override string ToString()
        {
            string yearCrop = Year.ToString().Remove(0, 2);

            return $"{Month}/{yearCrop}";
        }

    }
    public class CreditCard
    {
        private const int CVV_SIZE = 3;
        private const byte CVV_MAX = 9;
        private const byte CVV_MIN = 0;
        public const int CARD_NUMBER_DIGITS_COUNT = 16;
        
        public string NameOnTheCard { get; init; }

        public ExpiringDate ExpiringDate { get; init; }

        public byte[] CVV { get; init; }

        public decimal Balance { get => _balance; protected set => _balance = value; }

        public Currency Currency { get; init; }

        private decimal _balance;

        private byte[] _cardNumber;

        private CreditCard()
        {
            NameOnTheCard = "DEFAULT NAME";
            ExpiringDate = new ExpiringDate();
            CVV = new byte[CVV_SIZE] {7,7,7};
            _balance = 0.0M;
            Currency = Currency.UAH;
            _cardNumber = new byte[CARD_NUMBER_DIGITS_COUNT] {1,1,1,1,2,2,2,2,3,3,3,3,4,4,4,4 };
        }

        private CreditCard(string nameOnTheCard, byte[]cardNumber, ExpiringDate dateValue, Currency value)
        {
            NameOnTheCard = nameOnTheCard;
            _cardNumber = cardNumber;
            _balance = 0;

            Random randCVV = new Random();
            CVV = new byte[CVV_SIZE] 
            { (byte)randCVV.Next(CVV_MIN, CVV_MAX), 
                (byte)randCVV.Next(CVV_MIN, CVV_MAX), 
                (byte)randCVV.Next(CVV_MIN, CVV_MAX) 
            };

            ExpiringDate = dateValue;
            Currency = value;
        }

        public static CreditCard CreditCardBuild(string? nameOnTheCard, byte[] cardNumber, ExpiringDate dateValue, Currency value)
        {
            string _nameOnTheCard = string.Empty;
            byte[] _cardNumber = new byte[CARD_NUMBER_DIGITS_COUNT];

            if (nameOnTheCard != string.Empty && nameOnTheCard is not null)
                _nameOnTheCard = nameOnTheCard;
            else
                throw new NullReferenceException("Name cant be null or empty");

            if (cardNumber.Count() == CARD_NUMBER_DIGITS_COUNT)
                _cardNumber = cardNumber;
            else
                throw new IndexOutOfRangeException($"Digits count must be {CARD_NUMBER_DIGITS_COUNT}");

            return new CreditCard(_nameOnTheCard, _cardNumber, dateValue, value);

        }

        public static bool operator + (CreditCard card, decimal addValue)
        {
            if(card is null)
                return false;
            else
            {
                card.Balance += addValue;
                return true;
            }
           
        }

        public static bool operator - (CreditCard card, decimal minusValue)
        {
            if (card is null)
                return false;
            else
            {
                card.Balance -= minusValue;
                return true;
            }
        }

        public static bool operator > (CreditCard first, CreditCard second)
        {
            if (first is not null && second is not null)
                return first.Balance > second.Balance;
            else
                return false;
        }

        public static bool operator < (CreditCard first, CreditCard second) => !(first > second);

        public static bool operator == (CreditCard first, CreditCard second)
        {
            if (first is not null && second is not null)
                return first.CVV == second.CVV;
            else
                return false;
        }

        public static bool operator != (CreditCard first, CreditCard second) => !(first == second);

        public override bool Equals(object? obj)
        {
            var _object = obj as CreditCard;

            if (_object is not null)
                return _cardNumber == _object._cardNumber;
            else return false;
        }

        public override int GetHashCode()
        {
           string digits = string.Empty;
            
            foreach(var digit in _cardNumber)
            {
                digits += digit.ToString();
            }

            return digits.GetHashCode();
        }

        public override string ToString()
        {
            string cardNumber = ArrayToString<byte>(_cardNumber);
            string cvv = ArrayToString<byte>(CVV);


            return $"{cardNumber}\n" +
                $"{ExpiringDate}    CVV:{cvv}\n" +
                $"{NameOnTheCard}\n" +
                $"Ballance: {_balance.ToString("C",CultureInfo.InvariantCulture)} {Currency}";
        }

        private string ArrayToString<T>(T[]collection)
        {
            string buffer = string.Empty;

            if (collection is not null)
            {
                foreach (T item in collection)
                {
                    buffer += item.ToString();
                }
            }
            return buffer;
        }
    }
}
