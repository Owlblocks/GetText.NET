﻿using System.Collections.Generic;
using System.Globalization;
using GetText.Plural;
using Xunit;

namespace GetText.Tests.Plural
{
	public class DefaultPluralRuleGeneratorTest
	{
		#region Default forms

		[Fact]
		public void TestDefaultForms()
		{
			var dict = new Dictionary<string, Dictionary<long, int>>()
				{
					{"en-US", new Dictionary<long, int>()
						{
							{0, 1},
							{1, 0},
							{2, 1},
							{3, 1},
							{5, 1},
							{10, 1},
							{999, 1},
						}},
					{"fa-IR", new Dictionary<long, int>()
						{
							{0, 0},
							{1, 0},
							{2, 0},
							{3, 0},
							{5, 0},
							{10, 0},
							{999, 0},
						}},
					{"ar-SA", new Dictionary<long, int>()
						{
							{0, 0},
							{1, 1},
							{2, 2},
							{3, 3},
							{5, 3},
							{10, 3},
							{999, 5},
						}},
					{"hi", new Dictionary<long, int>()
						{
							{0, 0},
							{1, 0},
							{2, 1},
							{3, 1},
							{5, 1},
							{10, 1},
							{999, 1},
						}},
					{"fr", new Dictionary<long, int>()
						{
							{0, 0},
							{1, 0},
							{2, 1},
							{3, 1},
							{5, 1},
							{10, 1},
							{999, 1},
						}},
					{"lv", new Dictionary<long, int>()
						{
							{0, 0},
							{1, 1},
							{2, 2},
							{3, 2},
							{5, 2},
							{10, 2},
							{999, 2},
						}},
					{"se", new Dictionary<long, int>()
						{
							{0, 2},
							{1, 0},
							{2, 1},
							{3, 2},
							{5, 2},
							{10, 2},
							{999, 2},
						}},
					{"ru-RU", new Dictionary<long, int>()
						{
							{0, 2},
							{1, 0},
							{2, 1},
							{3, 1},
							{5, 2},
							{10, 2},
							{999, 2},
						}},
				};

			var generator = new DefaultPluralRuleGenerator();
			foreach (var testCase in dict)
			{
				var locale = new CultureInfo(testCase.Key);
				var rule = generator.CreateRule(locale);
				foreach (var data in testCase.Value)
				{
					Assert.Equal(data.Value, rule.Evaluate(data.Key));
				}
			}
		}

		#endregion
	}
}