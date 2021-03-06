﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace LiteDB
{
    public partial class BsonExpression
    {
        /// <summary>
        /// Return an array from list of values. Support multiple values but returns a single value
        /// </summary>
        public static IEnumerable<BsonValue> ARRAY(IEnumerable<BsonValue> values)
        {
            yield return new BsonArray(values);
        }

        /// <summary>
        /// Parse a JSON string into a new BsonDocument. Support multiple values (string only)
        /// </summary>
        public static IEnumerable<BsonValue> JSON(IEnumerable<BsonValue> values)
        {
            foreach (var value in values.Where(x => x.IsString))
            {
                yield return JsonSerializer.Deserialize(value);
            }
        }

        /// <summary>
        /// Return true if value is DATE. Support multiple values
        /// </summary>
        public static IEnumerable<BsonValue> IS_DATE(IEnumerable<BsonValue> values)
        {
            foreach (var value in values)
            {
                yield return value.IsDateTime;
            }
        }

        /// <summary>
        /// Return true if value is NUMBER (int, double, decimal). Support multiple values
        /// </summary>
        public static IEnumerable<BsonValue> IS_NUMBER(IEnumerable<BsonValue> values)
        {
            foreach (var value in values)
            {
                yield return value.IsNumber;
            }
        }


        /// <summary>
        /// Return true if value is STRING. Support multiple values
        /// </summary>
        public static IEnumerable<BsonValue> IS_STRING(IEnumerable<BsonValue> values)
        {
            foreach (var value in values)
            {
                yield return value.IsString;
            }
        }
    }
}
