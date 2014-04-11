﻿namespace AngleSharp.DOM.Css.Properties
{
    using System;

    /// <summary>
    /// More information available at:
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/column-gap
    /// </summary>
    sealed class CSSColumnGapProperty : CSSProperty
    {
        #region Fields

        static readonly Length _normal = new Length(1f, Length.Unit.Em);

        /// <summary>
        /// Defines the size of the gap between columns. It must not
        /// be negative, but may be equal to 0.
        /// </summary>
        Length _gap;

        #endregion

        #region ctor

        public CSSColumnGapProperty()
            : base(PropertyNames.ColumnGap)
        {
            _gap = _normal;
            _inherited = false;
        }

        #endregion

        #region Methods

        protected override Boolean IsValid(CSSValue value)
        {
            var gap = value.ToLength();

            if (gap.HasValue)
                _gap = gap.Value;
            else if (value is CSSIdentifierValue && ((CSSIdentifierValue)value).Value.Equals("normal"))
                _gap = _normal;
            else if (value != CSSValue.Inherit)
                return false;

            return true;
        }

        #endregion
    }
}
