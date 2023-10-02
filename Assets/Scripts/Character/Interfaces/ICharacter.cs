namespace Character.Interfaces
{
    public interface ICharacter
    {
        CharacterView CharacterView { get; }
        CharacterModel CharacterModel { get; }
    }
}
