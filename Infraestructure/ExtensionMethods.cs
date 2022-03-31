namespace System;

public static class ListExtensions {
    public static (List<T>,bool) ReplaceOldByNew<T>( this List<T> list, Predicate<T> oldItemSelector, T newItem) {
            var oldItemIndex = list.FindIndex(oldItemSelector);
            list[oldItemIndex] = newItem;
            return (list, true);
    }

    public static string Completion(this bool b) =>
        b ? "Operacion completada " : "La operacion no se completo";
    
}
