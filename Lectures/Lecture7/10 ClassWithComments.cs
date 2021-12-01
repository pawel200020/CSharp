namespace Lecture7.ClassWithComments
{
    /// <summary>
    /// Klasa przechowująca dane użytkownika
    /// </summary>
    class User
    {
        /// <summary>
        /// Pobiera, ustawia identyfikator bazodanowy użytkownika
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Pobiera, ustawia login konta użytkownika
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Pobiera, ustawia nazwę wyświetlaną użytkownika
        /// </summary>
        public string DisplayName { get; set; }
    }

    /// <summary>
    /// Klasa odpowiedzialna za operacje na repozyorium bazodanowym z użytkownikami
    /// </summary>
    class UserRepository
    {
        /// <summary>
        /// Pobiera z bazy danych informacje o użytkowniku o wskazanym id i zwraca w obiekcie typu <see cref="User"/>.
        /// </summary>
        /// <param name="id">Identyfikator bazodanowy użytkownika, którego dane mają być pobrane.</param>
        /// <returns>Obiekt typu <see cref="User"/> z danymi użytkownika.</returns>
        public User Get(int id)
        {
            return new User() { Id = id };
        }

    }
}
