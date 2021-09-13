import { SportEventsPage } from './app.po';

describe('sport-events App', () => {
  let page: SportEventsPage;

  beforeEach(() => {
    page = new SportEventsPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
