﻿namespace PaymentCenter.Core.ValuesObject
{
  public class NamePF : Name
  {
    public string First { get; set; }
    public string Last { get; set; }

    public void Validate()
    {
    }

    public NamePF(string first, string last)
    {
      First = first;
      Last = last;
      FullName = first + " " + last;

      Validate();
    }
  }
}
