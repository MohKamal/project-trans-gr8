# Modification Explanation
Here is a small explanation of the modifications made on the project

## Bug
THe bug was the If/If else condition in the SpellChecker.cs file, CanUserCastSpell function

## My Modifications

### User/Spell Mapper

The TransGr8-DD-Test\Helper\User is a field/property connection between the TransGr8-DD-Test\User and TransGr8-DD-Test\Spell, to make it easy for future dynamic condition checking.
```cs
        /// <summary>
        /// Spell components mapped with user fileds
        /// </summary>
        public Dictionary<string, string> SpellComponentsWithUserFileds
        {
            get
            {
                return new Dictionary<string, string>()
                {
                    {"V", "HasVerbalComponent" },
                    {"S", "HasSomaticComponent" },
                    {"M", "HasMaterialComponent" }
                };
            }
        }
```

### Logger

Using the Serilog package to display logs and save logs to files.
The LoggerHelper is static class to use the same Logger for the whole session, and save the logs to the same file.

### Services

To get users or spells data, i created a service to load data.

#### User Service

Load data from Json file

#### Spell Service

Load data from generated objects

### Interfaces

I create an interface for every dependent functionality of this project, like verifying the Range of the spell or the Duration.

### Abstract Spell Checker

The name is litte bite forward, but this class implements all the interfaces with virtual functions to be overrider at the future.
The main function CanUserCastSpell(User user, Spell spell) is not implemented in this class, it's left for the children classes to implement with the other functions

```cs
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
```

### Json file

Users data is stored in the json file ./data/users.json

# Dungeons & Dragons Spell Checker

As an avid D&D player, I have written an application which allows me to check if a user has the correct stats to cast spells in my quest. 

I have a found some bug in the code but not too sure about how to fix it. 

I have read some things online about a principal called SOLID and Rule Engines which I think may help me identify and fix the issue. 


## Task
1. I would like the code fixed so that we follow the new principal, without changing the signature of the Method `public bool CanUserCastSpell(User user, string spellName)` 
2. I would like the Bug identified and fixed
3. I would like the Unit Tests provided to be extended so they capture new tests as they are required


## Bug
The bug is defined as such:

When the Spell is "Cure Wounds" and the User DOES NOT HAVE "Somatic Component" then they are still able to cast the spell. 

### HINT
 The code which needs to be modified is centered in 2 files
 1. SpellChecker.cs
 2. SpellCheckerTests.cs

### Optional Extras (NOT REQUIRED)
1. Load all users into the application - Via a JSON File
2. Select a User to Check the Spell for
3. Use a Logger (Serilog) to write the messages rather than a Console.WriteLine statement.
