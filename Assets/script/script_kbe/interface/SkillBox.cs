namespace KBEngine
{
  	using UnityEngine; 
	using System; 
	using System.Collections; 
	using System.Collections.Generic;
	
    public class SkillBox 
    {
    	public static SkillBox inst = null;
    		
    	public List<Skill> skills = new List<Skill>();

        public Dictionary<string, UnityEngine.GameObject> dictSkillDisplay = new Dictionary<string,UnityEngine.GameObject>();
    	
		public SkillBox()
		{
			inst = this;
		}

        public void initSkillDisplay()
        {
            dictSkillDisplay["skill1"] = (UnityEngine.GameObject)Resources.Load("skill1");
            dictSkillDisplay["skill2"] = (UnityEngine.GameObject)Resources.Load("skill2");
            dictSkillDisplay["skill3"] = (UnityEngine.GameObject)Resources.Load("skill3");
            dictSkillDisplay["skill4"] = (UnityEngine.GameObject)Resources.Load("skill4");
            dictSkillDisplay["skill5"] = (UnityEngine.GameObject)Resources.Load("skill5");
            dictSkillDisplay["skill6"] = (UnityEngine.GameObject)Resources.Load("skill6");
        }
		
		public void pull()
		{
			clear();
			
			KBEngine.Entity player = KBEngineApp.app.player();
			if(player != null)
				player.cellCall("requestPull");
		}
		
		public void clear()
		{
			skills.Clear();
		}
		
		public void add(Skill skill)
		{
			for(int i=0; i<skills.Count; i++)
			{
				if(skills[i].id == skill.id)
				{
					Dbg.DEBUG_MSG("SkillBox::add: " + skill.id  + " is exist!");
					return;
				}
			}
			
			skills.Add(skill);
		}
		
		public void remove(Int32 id)
		{
			for(int i=0; i<skills.Count; i++)
			{
				if(skills[i].id == id)
				{
					skills.RemoveAt(i);
					return;
				}
			}
		}
		
		public Skill get(Int32 id)
		{
			for(int i=0; i<skills.Count; i++)
			{
				if(skills[i].id == id)
				{
					return skills[i];
				}
			}
			
			return null;
		}
    }
} 
