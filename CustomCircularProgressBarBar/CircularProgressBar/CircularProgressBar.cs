using System;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Views;


namespace CustomCircularProgressBarBar
{
    public class CircularProgressBar : View
    {
        private const float Max = 100;
        private const float Min = 0;
        private float _radius;
        private readonly RectF _arcBounds = new RectF();
        private float _progress;


        public float Progress
        {
            get { return _progress; }
            set
            {
                if (value > Max)
                {
                    _progress = Max;
                }
                else if (value < Min)
                {
                    _progress = Min;
                }
                else
                {
                    _progress = value;
                }
                Invalidate();
            }
        }

        public CircularProgressBar(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public CircularProgressBar(Context context) : base(context)
        {
        }

        public CircularProgressBar(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public CircularProgressBar(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
        }

        public CircularProgressBar(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
        }

        protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
        {
            _radius = Math.Min(w, h) / 2f;
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            int w = MeasureSpec.GetSize(widthMeasureSpec);
            int h = MeasureSpec.GetSize(heightMeasureSpec);

            int size = Math.Min(w, h);
            SetMeasuredDimension(size, size);
        }

        protected override void OnDraw(Canvas canvas)
        {
            var mPaint = new Paint(PaintFlags.FilterBitmap |
                                   PaintFlags.Dither |
                                   PaintFlags.AntiAlias)
            {
                Dither = true,
                Color = Color.Gray
            };

            mPaint.SetStyle(Paint.Style.Stroke);
            mPaint.StrokeWidth = 2;

            //Circle
            float mouthInset = _radius / 3f;
            _arcBounds.Set(mouthInset, mouthInset, _radius * 2 - mouthInset, _radius * 2 - mouthInset);
            canvas.DrawArc(_arcBounds, 270f, 360, false, mPaint);

            //Arc
            mPaint.Color = Color.ParseColor("#33b5e5");
            mPaint.StrokeWidth = 15;
            float sweep = 360 * _progress * 0.01f;
            canvas.DrawArc(_arcBounds, 0, sweep, false, mPaint);


            //Progress Text
            mPaint.TextSize = 50;
            mPaint.StrokeWidth = 4;
            mPaint.TextAlign = Paint.Align.Center;
            float textHeight = mPaint.Descent() - mPaint.Ascent();
            float textOffset = (textHeight / 2) - mPaint.Descent();
            canvas.DrawText(_progress + "%", _arcBounds.CenterX(), _arcBounds.CenterY() + textOffset, mPaint);
        }
    }
}