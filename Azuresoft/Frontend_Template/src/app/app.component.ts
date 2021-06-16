import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  perfData: any;
  EstimatedTime: any;
  time: any;
  PercentageID: any;
  start: any;
  end: any;
  durataion: any;
  doneLoading = false;

  ngOnInit() {
    this.startLoader();
  }
  animateValue(id: any, start: any, end: any, duration: any) {
    const range = end - start;
    let current = start;
    const increment = end > start ? 1 : -1;
    const stepTime = Math.abs(Math.floor(duration / range));
    const obj = $(id);
    const timer = setInterval(() => {
      current += increment;
      $(obj).text(current);
      if (current === end) {
        clearInterval(timer);
      }
    }, stepTime);
  }
  startLoader() {
    $('body').addClass('noscroll');
    $('html').addClass('noscroll');
    this.perfData = window.performance.timing;
    this.EstimatedTime = -(this.perfData.loadEventEnd - this.perfData.navigationStart);
    this.time = ((this.EstimatedTime / 1000) % 50) * 100;
    // Percentage Increment Animation
    this.PercentageID = $('.percentage');
    this.start = 0;
    this.end = 100;
    this.durataion = this.time;
    this.animateValue(this.PercentageID, this.start, this.end, this.durataion);
    setTimeout(() => {
      $('.preloader').fadeOut();
      $('body').removeClass('noscroll').dequeue();
      $('html').removeClass('noscroll').dequeue();
      $('.cd-transition-layer').addClass('closing').delay(1000).queue(() => {
        $(this).removeClass('visible closing opening').dequeue();
        $('#cloud').remove();
        this.doneLoading = true;
      });
    }, this.time);
  }
}
