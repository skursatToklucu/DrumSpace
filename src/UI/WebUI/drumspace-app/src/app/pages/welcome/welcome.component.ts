import {Component, OnInit} from '@angular/core';
import Vex from 'vexflow';


@Component({
  selector: 'app-welcome',
  templateUrl: './welcome.component.html',
  styleUrls: ['./welcome.component.css']
})
export class WelcomeComponent implements OnInit {
  VF: Vex.Flow;
  score;
  system;

  constructor() {
  }

  ngOnInit() {
    const {Factory, EasyScore, System} = Vex.Flow;

    const vf = new Factory({
      renderer: {elementId: 'output', width: 500, height: 200},
    });

    const score = vf.EasyScore();
    const system = vf.System();

    system
      .addStave({
        voices: [
          score.voice(score.notes('C#5/q, B4, A4, G#4', {stem: 'up'})),
          // score.voice(score.notes('C#4/h, C#4', {stem: 'down'})),
        ],
      })
      .addClef('treble')
      .addTimeSignature('4/4');

    vf.draw();
  }

  createStave() {
  }
}
