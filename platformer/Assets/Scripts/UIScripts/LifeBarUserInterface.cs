using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UIScripts
{
    public class LifeBarUserInterface : MonoBehaviour
    {
        public float heartSize = 21.2f;

        public Sprite fullHeart;
        public Sprite halfHeart;
        public Sprite emptyHeart;

        public enum HeartType
        {
            EmptyHeart,
            HalfHeart,
            FullHeart
        }
    
        private List<HeartImage> _heartImageList;
        private const int MaxHeartsInRow = 8;
        private int _rowOfHeart;

        public void Awake()
        {
            _heartImageList = new List<HeartImage>();
        }

        public void InitializeLifeBar(int numOfHearts)
        {
            for (var columnOfHearts = 0; _heartImageList.Count < numOfHearts; columnOfHearts++)
            {
                if (columnOfHearts == MaxHeartsInRow)
                {
                    _rowOfHeart++;
                    columnOfHearts -= columnOfHearts;
                }
                CreateHeart(new Vector2(columnOfHearts * heartSize, _rowOfHeart * heartSize * -1), _heartImageList.Count)
                    .SetHeartFragments(HeartType.FullHeart);
            }
        }

        private HeartImage CreateHeart(Vector2 anchoredPosition, int heartNum)
        {
            var heart = new GameObject("Heart" + heartNum, typeof(Image));
        
            heart.transform.SetParent(transform);
            heart.transform.localPosition = Vector3.zero;

            heart.GetComponent<RectTransform>().anchoredPosition = anchoredPosition;
            heart.GetComponent<RectTransform>().sizeDelta = new Vector2(heartSize,heartSize);
            

            var heartImageUi = heart.GetComponent<Image>();
            heartImageUi.sprite = fullHeart;

            var heartImage = new HeartImage(this, heartImageUi);
            _heartImageList.Add(heartImage);
            return heartImage;
        }
    
        public class HeartImage
        {
            private readonly Image _heartImage;
            private readonly LifeBarUserInterface _lifeBar;
            public HeartImage(LifeBarUserInterface lifeBar, Image heartImage)
            {
                _lifeBar = lifeBar;
                _heartImage = heartImage;
            }
        
            public void SetHeartFragments(HeartType fragments)
            {
                switch (fragments)
                {
                    case HeartType.FullHeart :
                        _heartImage.sprite = _lifeBar.fullHeart;
                        break;
                    case HeartType.HalfHeart :
                        _heartImage.sprite = _lifeBar.halfHeart;
                        break;
                    case HeartType.EmptyHeart :
                        _heartImage.sprite = _lifeBar.emptyHeart;
                        break;
                }
            }
        }

    }
}
