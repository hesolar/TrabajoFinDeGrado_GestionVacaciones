﻿namespace Infrastructure;
public static class PropertyCopier<TParent, TChild> where TParent : class
                                             where TChild : class {
    public static void Copy(TParent parent, TChild child) {
        var parentProperties = parent.GetType().GetProperties();
        var childProperties = child.GetType().GetProperties();

        foreach (var parentProperty in parentProperties) {
            foreach (var childProperty in childProperties) {
                if (parentProperty.Name == childProperty.Name && parentProperty.PropertyType == childProperty.PropertyType) {
                    var propertyValue = parentProperty.GetValue(parent);
                    if (propertyValue!=null) childProperty.SetValue(child, propertyValue);
                    break;
                }
            }
        }
    }
}