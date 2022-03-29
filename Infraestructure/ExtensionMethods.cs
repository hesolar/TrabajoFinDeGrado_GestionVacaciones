namespace System;

public static class ListExtensions {
    public static (List<T>,bool) ReplaceOldByNew<T>( this List<T> list, Predicate<T> oldItemSelector, T newItem) {
            var oldItemIndex = list.FindIndex(oldItemSelector);
            list[oldItemIndex] = newItem;
            return (list, true);
    }
    public static async Task<bool> Deletion<T>(this List<T> list, Predicate<T> oldItemSelector) {
        //check for different situations here and throw exception
        //if list contains multiple items that match the predicate
        //or check for nullability of list and etc ...
         //{
            var oldItemIndex = list.FindIndex(oldItemSelector);
            list.RemoveAt(oldItemIndex);
            return true;
        //}
        //catch (Exception) { return false; }
    }
    public static string Completion(this bool b) =>
        b ? "Operacion completada " : "La operacion no se completo";
    
}
