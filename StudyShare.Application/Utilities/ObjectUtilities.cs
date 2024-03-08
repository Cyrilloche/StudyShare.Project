using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace StudyShare.Application.Utilities
{
    public class ObjectUtilities
    {
        public static void ObjectUpdater<T1, T2>(T1 normalObject, T2 updateObject)
        {
            // On récupère les propriétés de l'objet à Update
            var propertiesToUpdate = typeof(T2).GetProperties();


            foreach (var property in propertiesToUpdate)
            {
                // On recupère la valeur de la propriété de l'objet à mettre à jour
                var updatedValue = property.GetValue(updateObject);


                if(updatedValue != null)
                {
                    // On recupère la propriété de l'objet normal
                    var existingProperty = typeof(T1).GetProperty(property.Name);

                    if (existingProperty != null)
                        // Mets à jour la valeur de la propriété dans l'objet normal
                        existingProperty?.SetValue(normalObject, updateObject);
                }
            }
        }

        public static TDto ObjectMapper<T, TDto>(T obj) where TDto : new()
        {
            TDto dto = new TDto();
            PropertyInfo[] objProperties = typeof(T).GetProperties();
            PropertyInfo[] dtoProperties = typeof(TDto).GetProperties();

            foreach (var dtoProperty in dtoProperties)
            {
                var objProperty = Array.Find(objProperties, p => p.Name == dtoProperty.Name && p.PropertyType == dtoProperty.PropertyType);
                if (objProperty != null)
                {
                    object value = objProperty.GetValue(obj);
                    dtoProperty.SetValue(dto, value);
                }
            }
            return dto;
        }
    }
}