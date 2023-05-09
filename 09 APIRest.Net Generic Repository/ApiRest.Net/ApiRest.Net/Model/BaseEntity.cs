using System;
using System.ComponentModel.DataAnnotations.Schema;

public class BaseEntity
{
	public BaseEntity()
	{
	}
	[Column("id")]
	public int Id { get; set; }
}
