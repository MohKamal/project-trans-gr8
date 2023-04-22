using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransGr8_DD_Test.Helpers;
using TransGr8_DD_Test.Interfaces;
using Serilog;
using Serilog.Core;

namespace TransGr8_DD_Test
{
    /// <summary>
    /// Abstract class that impliment all the necessary interfaces for the SpellChecker
    /// All the function are virtual to be overrider in the future
    /// </summary>
    public abstract class AbstractSpellChecker: IUserComponent, UserAndSpellCondition, IUserDuration
    {     
        /// <summary>
        /// Get user/spell mapping
        /// </summary>
        protected Maper _maper { get; set; }
        public AbstractSpellChecker()
        {
            this._maper = new Maper();
        }

        /// <summary>
        /// Get the value of an object property using it's name as string
        /// </summary>
        /// <param name="src"></param>
        /// <param name="propName"></param>
        /// <returns></returns>
        private object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }

        /// <summary>
        /// Check if the user has all the spell components
        /// </summary>
        /// <param name="user"></param>
        /// <param name="spell"></param>
        /// <returns></returns>
        public virtual bool HasUserSpellComponents(User user, Spell spell)
        {
            if (user == null || spell == null)
            {
                LoggerHelper.Log().Error("User or/and spell not provided");
                return false;
            }

            foreach(string component in spell.getCompoents())
            {
                string _component = component.Replace(" ", string.Empty);
                if (_component.Length == 1)
                {
                    var result = GetPropValue(user, _maper.SpellComponentsWithUserFileds.GetValueOrDefault(_component));
                    if(result is bool)
                    {
                        LoggerHelper.Log().Debug("Checking for spell component {0} : " + ((bool)result == false ? " user don't have it" : " user have it"), _component);
                        if ((bool)result == false) return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Check if the user has a specific spell component
        /// </summary>
        /// <param name="user"></param>
        /// <param name="spell"></param>
        /// <param name="component"></param>
        /// <returns></returns>
        public virtual bool HasUserSpellComponent(User user, Spell spell, string component)
        {
            if (user == null || spell == null || component == null)
            {
                LoggerHelper.Log().Error("User or/and spell or/and component not provided");
                return false;
            }

            if(spell.getCompoents().Contains(component))
            {
                var result = GetPropValue(user, _maper.SpellComponentsWithUserFileds.GetValueOrDefault(component));
                if (result is bool)
                {
                    LoggerHelper.Log().Debug("Checking for spell component {0} : " + ((bool)result == false ? " user don't have it" : " user have it"), component);
                    return (bool)result;
                }
            }

            return false;
        }

        /// <summary>
        /// Check if the user a spell condition
        /// A same propetry in both the user and spell, like Level, Range...
        /// </summary>
        /// <param name="user"></param>
        /// <param name="spell"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        public virtual bool HasUserASpellCondition(User user, Spell spell, string property)
        {
            LoggerHelper.Log().Information("Checking if user has a spell requirement: {0}.", property);
            if (spell.PropertyToIgnoreOnChecking.Contains(property))
            {
                LoggerHelper.Log().Error("The {0} property does not exist in the {1} spell.", property, spell.Name);
                return false;
            }
            var user_value = GetPropValue(user, property);
            var spell_value = GetPropValue(spell, property);
            if (user_value == null || spell_value == null)
            {
                LoggerHelper.Log().Error("The {0} property does not exist in the {1} spell or/and the provided user.", property, spell.Name);
                return false;
            }
            if (user_value is int && spell_value is int)
            {
                LoggerHelper.Log().Debug("resilts : user ({0}) is {1} than {2} spell.", user_value.ToString(), ((int)user_value >= (int)spell_value ? "Higher or equal" : "Lower"), spell_value.ToString());
                return (int)user_value >= (int)spell_value;
            }

            return false;
        }

        /// <summary>
        /// Check if the user has a spell duration
        /// </summary>
        /// <param name="user"></param>
        /// <param name="spell"></param>
        /// <returns></returns>
        public virtual bool HasUserDuration(User user, Spell spell)
        {
            LoggerHelper.Log().Information("Checking if user has a spell duration.");
            string user_property = _maper.SpellDurationsWithUserFileds.GetValueOrDefault(spell.Duration);
            if (string.IsNullOrEmpty(user_property))
            {
                LoggerHelper.Log().Debug("results: true");
                return true;
            }

            var result = GetPropValue(user, user_property);

            if (result is bool)
            {
                LoggerHelper.Log().Debug("results: {0}", ((bool)result).ToString());
                return (bool)result;

            }
            LoggerHelper.Log().Debug("results: false");

            return false;
        }

        /// <summary>
        /// Check if the user has spell saving throw
        /// </summary>
        /// <param name="user"></param>
        /// <param name="spell"></param>
        /// <returns></returns>
        public virtual bool HasUserSavingThrow(User user, Spell spell)
        {
            LoggerHelper.Log().Information("Checking if user has a spell saving throws.");
            if (string.IsNullOrEmpty(spell.SavingThrow)) {
                LoggerHelper.Log().Debug("Spell don't have any saving throws");
                return true;
            }

            string user_property = _maper.SpellSavingThrowWithUserFileds.GetValueOrDefault(spell.SavingThrow);
            if (string.IsNullOrEmpty(user_property))
            {
                LoggerHelper.Log().Debug("User don't have the spell saving throws");
                return false;
            }

            var result = GetPropValue(user, user_property);

            if (result is bool)
            {
                LoggerHelper.Log().Debug("results: " + ((bool)result).ToString());
                return (bool)result;
            }
            LoggerHelper.Log().Debug("results: false");
            return false;
        }

        /// <summary>
        /// Obligatory function to check if the user can cast a spell
        /// This function will regroup all the function above to give a proper results
        /// </summary>
        /// <param name="user"></param>
        /// <param name="spellName"></param>
        /// <returns></returns>
        public virtual bool CanUserCastSpell(User user, string spellName)
        {
            return true;
        }
    }
}
