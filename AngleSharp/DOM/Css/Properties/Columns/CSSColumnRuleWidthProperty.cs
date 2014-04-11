﻿namespace AngleSharp.DOM.Css.Properties
{
    using System;

    /// <summary>
    /// More information available at:
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/column-rule-width
    /// </summary>
    sealed class CSSColumnRuleWidthProperty : CSSProperty
    {
        #region Fields

        /// <summary>
        /// Describes the width of the rule separating two columns.
        /// </summary>
        Length _width;

        #endregion

        #region ctor

        public CSSColumnRuleWidthProperty()
            : base(PropertyNames.ColumnRuleWidth)
        {
            _width = new Length(1f, Length.Unit.Px);
            _inherited = false;
        }

        #endregion

        #region Methods

        protected override Boolean IsValid(CSSValue value)
        {
            var width = value.ToBorderWidth();

            if (width.HasValue)
                _width = width.Value;
            else if (value != CSSValue.Inherit)
                return false;

            return true;
        }

        #endregion
    }
}
