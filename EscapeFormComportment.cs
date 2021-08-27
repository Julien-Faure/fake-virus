using System;

namespace WindowsFormsApp1
{
    public class EscapeFormComportment
    {
        private const int XOffset = 20; 
        private const int YOffset = 30; 
        private const int XMoveRange = 30; 
        private const int YMoveRange = 30; 
        
        private readonly int _formWidth;
        private readonly int _formHeight;
        private readonly int _screenWidth;
        private readonly int _screenHeight;
        
        private int _form1OriginalX;
        private int _form1OriginalY;
        private Action<int, int> _updateFormPosition = (i, i1) => { };
        private int _formX1, _formY1, _formX2, _formY2;

        public EscapeFormComportment(int formWidth, int formHeight, int screenWidth, int screenHeight)
        {
            _formWidth = formWidth;
            _formHeight = formHeight;
            _screenWidth = screenWidth;
            _screenHeight = screenHeight;
        }
        
        public void SetUpdateFormPositionEvent(Action<int,int> action){
            _updateFormPosition = action;
        }

        public void UpdateMousePosition(int cursorX, int cursorY, int formX, int formY)
        {
            CalculatePositions(formX, formY);

            bool cursorIsInXRange = cursorX > _formX1 && cursorX < _formX2;
            bool cursorIsInYRange = cursorY > _formY1 && cursorY < _formY2;

            if (cursorIsInXRange && cursorIsInYRange)
            {
                MakeTheFormEscapeFromTheCursor(cursorX, cursorY);
                HandleScreenBoundsCollision();
            }
        }

        private void CalculatePositions(int formX, int formY)
        {
            _form1OriginalX = formX;
            _form1OriginalY = formY;

            _formX1 = _form1OriginalX - XOffset;
            _formY1 = _form1OriginalY - YOffset;
            _formX2 = _formX1 + _formWidth + XOffset;
            _formY2 = _formY1 + _formHeight + YOffset;
        }

        private void MakeTheFormEscapeFromTheCursor(int cursorX, int cursorY)
        {
            bool ifCursorIsInFirstHalfOfXRange = cursorX > _formX1 && cursorX < (_formX1 + (_formWidth / 2));
            bool ifCursorIsInFirstHalfOfYRange = cursorY > _formY1 && cursorY < (_formY1 + (_formHeight / 2));

            if (ifCursorIsInFirstHalfOfXRange && ifCursorIsInFirstHalfOfYRange)
                _updateFormPosition(_form1OriginalX + XMoveRange, _form1OriginalY + YMoveRange);
            else if (ifCursorIsInFirstHalfOfXRange) //&& !ifCursorIsInFirstHalfOfYRange
                _updateFormPosition(_form1OriginalX + XMoveRange, _form1OriginalY - YMoveRange);
            else if (ifCursorIsInFirstHalfOfYRange) //&& !ifCursorIsInFirstHalfOfXRange
                _updateFormPosition(_form1OriginalX - XMoveRange, _form1OriginalY + YMoveRange);
            else
                _updateFormPosition(_form1OriginalX - XMoveRange, _form1OriginalY - YMoveRange);
        }

        private void HandleScreenBoundsCollision()
        {
            if ((_form1OriginalX + _formWidth) >= _screenWidth)
                _updateFormPosition(0, _form1OriginalY);
            else if (_form1OriginalX < 0)
                _updateFormPosition(_screenWidth - _formWidth, _form1OriginalY);

            if ((_form1OriginalY + _formHeight) >= _screenHeight)
                _updateFormPosition(_form1OriginalX, 0);
            else if (_form1OriginalY < 0)
                _updateFormPosition(_form1OriginalX, _screenHeight - _formHeight);
        }
    }
}