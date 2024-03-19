using System.Reflection;

namespace StudyShare.Domain.Utilities
{
    public class ObjectUtilities
    {

        // Méthode pour mettre à jour un objet existant en fonction d'un autre objet
        public static void UpdateObject<T1, T2>(T1 existingObject, T2 updatedObject)
        {
            // Obtenir toutes les propriétés de l'objet mis à jour (updatedObject)
            var propertiesToUpdate = typeof(T2).GetProperties();

            // Parcourir chaque propriété de l'objet mis à jour
            foreach (var property in propertiesToUpdate)
            {
                // Obtenir la valeur de la propriété mise à jour
                var updatedValue = property.GetValue(updatedObject);

                // Vérifier si la valeur mise à jour n'est pas nulle
                if (updatedValue != null)
                {
                    // Obtenir la propriété correspondante de l'objet existant (existingObject)
                    var existingProperty = typeof(T1).GetProperty(property.Name);

                    // Vérifier si la propriété existe dans l'objet existant
                    existingProperty?.SetValue(existingObject, updatedValue);
                }
            }
        }

        // Méthode pour mapper un objet DTO (Data Transfer Object) à un objet de destination
        public static T MapObject<T>(object dto)
        {
            // Vérifier si l'objet DTO est nul
            if (dto == null)
                return default!;

            // Obtenir le type de l'objet de destination
            Type type = typeof(T);

            // Créer une nouvelle instance de l'objet de destination
            T obj = (T)Activator.CreateInstance(type)!;

            // Obtenir toutes les propriétés de l'objet DTO
            PropertyInfo[] dtoProperties = dto.GetType().GetProperties();

            // Obtenir toutes les propriétés de l'objet de destination
            PropertyInfo[] objProperties = type.GetProperties();

            // Parcourir chaque propriété de l'objet de destination
            foreach (PropertyInfo objProp in objProperties)
            {
                // Obtenir la propriété correspondante de l'objet DTO
                PropertyInfo dtoProp = dtoProperties.FirstOrDefault(p => p.Name == objProp.Name)!;

                // Vérifier si la propriété existe dans l'objet DTO
                if (dtoProp != null)
                {
                    // Obtenir la valeur de la propriété dans l'objet DTO
                    object value = dtoProp.GetValue(dto)!;

                    // Vérifier si le nom de la propriété est différent de "userpassword"
                    if (objProp.Name.ToLower() != "userpassword")
                    {
                        // Convertir la valeur en minuscules si elle est de type string
                        if (value != null && value is string v)
                            value = v.ToLower();
                    }

                    // Définir la valeur de la propriété dans l'objet de destination
                    objProp.SetValue(obj, value);
                }
            }

            // Retourner l'objet de destination
            return obj;
        }

    }
}