﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PhonebookApp.Domain {
    using System;
    
    
    /// <summary>
    ///   Класс ресурса со строгой типизацией для поиска локализованных строк и т.д.
    /// </summary>
    // Этот класс создан автоматически классом StronglyTypedResourceBuilder
    // с помощью такого средства, как ResGen или Visual Studio.
    // Чтобы добавить или удалить член, измените файл .ResX и снова запустите ResGen
    // с параметром /str или перестройте свой проект VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class SQL {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal SQL() {
        }
        
        /// <summary>
        ///   Возвращает кэшированный экземпляр ResourceManager, использованный этим классом.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("PhonebookApp.Domain.SQL", typeof(SQL).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Перезаписывает свойство CurrentUICulture текущего потока для всех
        ///   обращений к ресурсу с помощью этого класса ресурса со строгой типизацией.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на delete from Phonebook
        ///where PersonId = @PersonId.
        /// </summary>
        internal static string DeletePhoneNumbersByPersonId {
            get {
                return ResourceManager.GetString("DeletePhoneNumbersByPersonId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на insert into Person (Name, Surname, Patronymic)
        ///output inserted.Id
        ///values (@Name, @Surname, @Patronymic);.
        /// </summary>
        internal static string InsertPerson {
            get {
                return ResourceManager.GetString("InsertPerson", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на insert into Phonebook (PersonId, Phonenumber)
        ///values (@PersonId, @Phonenumber);.
        /// </summary>
        internal static string InsertPhoneNumbers {
            get {
                return ResourceManager.GetString("InsertPhoneNumbers", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на select 
        ///	p.Name,
        ///	p.Surname,
        ///	p.Patronymic
        ///from Person p
        ///where p.Id = @Id.
        /// </summary>
        internal static string SelectPersonById {
            get {
                return ResourceManager.GetString("SelectPersonById", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на select 
        ///	b.PhoneNumber
        ///from Phonebook b
        ///where b.PersonId = @PersonId.
        /// </summary>
        internal static string SelectPhoneNumbersByPersonId {
            get {
                return ResourceManager.GetString("SelectPhoneNumbersByPersonId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на update Person
        ///set Name = @Name,
        ///	Surname = @Surname,
        ///	Patronymic = @Patronymic
        ///where Id = @Id.
        /// </summary>
        internal static string UpdatePerson {
            get {
                return ResourceManager.GetString("UpdatePerson", resourceCulture);
            }
        }
    }
}
