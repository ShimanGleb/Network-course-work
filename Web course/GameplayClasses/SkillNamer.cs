using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameplayClasses
{
    public class SkillNamer
    {
        public void NameSkill(Skill skill, string name, string description)
        {
            skill.name = name;
            skill.description = description;
        }
    }
}
