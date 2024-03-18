namespace SerializationThings
{
    /// <summary>
    /// A basic class with two 'required' properties used for serialization examples. The required keyword makes the JsonSerialiser
    /// require exact casing for the property names when deserialising.
    /// </summary>
    class PersonRequired
    {
        public required string Name { get; set; }
        public required int Age { get; set; }
    }
}
