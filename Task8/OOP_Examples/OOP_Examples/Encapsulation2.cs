namespace OOP_Examples
{
    /// <summary>
    /// Bad encapsulation example
    /// because data and methods are
    /// separated
    /// </summary>
    public class Encapsulation2
    {
        class Data
        {
            public string DataString { get; set; }
        }

        class Methods
        {
            /// <summary>
            /// Check's data from Data class
            /// </summary>
            /// <param name="userData">User data to check</param>
            /// <returns>true if data is valid, overwise return false</returns>
            public bool CheckData(Data userData)
            {
                if (string.IsNullOrEmpty(userData.DataString))
                {
                    return false;
                }
                return true;
            }
        }
    }
}