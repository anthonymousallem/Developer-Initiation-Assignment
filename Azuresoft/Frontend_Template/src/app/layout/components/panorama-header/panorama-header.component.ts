import { Component, OnInit } from '@angular/core';
declare function initLayout(): any;

@Component({
  selector: 'panorama-header',
  templateUrl: './panorama-header.component.html',
  styleUrls: ['./panorama-header.component.scss']
})
export class PanoramaHeaderComponent implements OnInit {
  constructor() { }

  ngOnInit(): void {
    initLayout();
  }
}
