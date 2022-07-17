using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;


[Serializable]
public partial class Keys
{
  [FieldKey(categoryName = "Unit")] public const string Hero = "Hero";
  [FieldKey(categoryName = "Unit/Mobs")] public const string Rabbit = "Rabbit";
}


[Serializable]
public class KeyFilter : PropertyAttribute
{
  public Type Type { get; private set; }

  public KeyFilter(Type type)
  {
    Type = type;
  }
}


[AttributeUsage(AttributeTargets.Field)]
public class FieldKeyAttribute : Attribute
{
  public string categoryName;
}


/*
public static class HelperTags
{
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static string MyTagToString(in this int tag) => dictTagsString[tag];

  static Dictionary<int, string> dictTagsString;

  [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
  static void TagToStringBeforeSceneLoad()
  {
    dictTagsString = new Dictionary<int, string>();
    List<string> listTagName = GetMembersStringTags();

    for (int i = 1; i < listTagName.Count; i++)
    {
      int tagId = (int) GetFieldId(listTagName[i]);
      dictTagsString.Add(tagId, listTagName[i]);
    }
  }

  [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
  public static void CheckDuplicateID()
  {
    List<string> listTagName = GetMembersStringTags();
    List<int> listTagID = new List<int>();

    for (int i = 1; i < listTagName.Count; i++)
    {
      int tagId = (int) GetFieldId(listTagName[i]);
      listTagID.Add(tagId);
    }

    var listDuplicateID = listTagID.GroupBy(x => x).Where(x => x.Count() != 1).Select(x => x.Key).ToList();

    if (listDuplicateID.Count != 0)
    {
      var listDuplicateName = new List<string>();
      for (int i = 1; i < listTagName.Count; i++)
      {
        int tagId = (int) GetFieldId(listTagName[i]);

        if (listDuplicateID.Any(t => t == tagId)) listDuplicateName.Add(listTagName[i]);
      }

      foreach (var v in listDuplicateName)
      {
        Debug.LogError($"Tag дубликат: {v} = {(int) GetFieldId(v)}");
      }
    }
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static List<string> GetMembersStringTags()
  {
    // Get the Type and MemberInfo.
    Type t = Type.GetType("Tags");
    if (t == default)
    {
      t = Type.GetType("Pixeye.Framework.Tags");
      if (t == default) Debug.LogError("Не найден класс Tags в проекте");
    }

    MemberInfo[] memberArray = t.GetMembers();

    List<string> memberString = new List<string>();
    foreach (var member in memberArray)
    {
      if (member.DeclaringType.ToString() == t.FullName) memberString.Add(member.Name);
    }

    return memberString;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static object GetFieldId(string fieldName) => typeof(Tags).GetField(fieldName, BindingFlags.Public | BindingFlags.Static).GetValue(null);
}
*/



