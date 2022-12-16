namespace recipe_api.Services;

public interface IHashService
{
    string HashString(string text);

    string DecryteString(string cryptedText);
}
