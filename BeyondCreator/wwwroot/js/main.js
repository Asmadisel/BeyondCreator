let continents = document.querySelectorAll('.continent');
let popupBg = document.querySelector('.info__bg');
let popup__photo = document.querySelector('.info__photo');
let popup__title = document.querySelector('.info__title');
let popup__text = document.querySelector('.info__text');
let tooltip = document.querySelector('.tooltip');
let popup__link = document.querySelector('.info__button');

continents.forEach((item) => {
  item.addEventListener('click', function () {
    popup__title.textContent = this.getAttribute('data-title');
    popup__photo.setAttribute('src', this.getAttribute('data-photo'));
    popup__text.textContent = this.getAttribute('data-text');
    popup__link.setAttribute('href', this.getAttribute('data-link'));

    popupBg.classList.add('active');
  });

  item.addEventListener('mouseenter', function () {
    tooltip.textContent = item.getAttribute('data-title');
    tooltip.style.display = 'block';
  });

  item.addEventListener('mouseleave', function () {
    tooltip.textContent = item.getAttribute('data-title');
    tooltip.style.display = 'none';
  });

  item.addEventListener('mousemove', function (e) {
    tooltip.style.top = e.y + 20 + 'px';
    tooltip.style.left = e.x + 20 + 'px';
  });
});

document.addEventListener('click', (e) => {
  if (e.target === popupBg) {
    popupBg.classList.remove('active');
  }
});
