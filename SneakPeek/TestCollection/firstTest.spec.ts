import {test} from '@playwright/test'

test('the first test', async ({page}) => {
    await page.goto('http://localhost:5098/')
 });